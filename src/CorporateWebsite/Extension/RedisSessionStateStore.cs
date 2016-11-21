using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Specialized;
using CorporateWebsite.Infrastructure.Redis;
using Newtonsoft.Json;

namespace CorporateWebsite.Extension
{
    /// <summary>
    /// 使用Cookie实现SessionStateStoreProviderBase
    /// 在使用System.Web中的Session["key"]="caixiao"时，自动将value存入redis中
    /// 注意：它只适合保存简单的基元类型数据。
    /// </summary>
    public class RedisSessionStateStore : SessionStateStoreProviderBase
    {
        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return CreateLegitStoreData(context, null, null, timeout);
        }

        internal static SessionStateStoreData CreateLegitStoreData(HttpContext context, ISessionStateItemCollection sessionItems, HttpStaticObjectsCollection staticObjects, int timeout)
        {
            if (sessionItems == null)
                sessionItems = new SessionStateItemCollection();
            if (staticObjects == null && context != null)
                staticObjects = SessionStateUtility.GetSessionStaticObjects(context);
            return new SessionStateStoreData(sessionItems, staticObjects, timeout);
        }

        public override void CreateUninitializedItem(HttpContext context, string id, int timeout)
        {
            RedisSessionState state = new RedisSessionState(null, null, timeout);
            RedisBase.Item_Set<string>(id, state.ToJson(),timeout);
        }

        private SessionStateStoreData DoGet(HttpContext context, string id, bool exclusive, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actionFlags)
        {
            locked = false;
            lockId = null;
            lockAge = TimeSpan.Zero;
            actionFlags = SessionStateActions.None;
            RedisSessionState state = RedisSessionState.FromJson(RedisBase.Item_Get<string>(id));
            if (state == null)
            {
                return null;
            }
            RedisBase.Item_SetExpire(id, state._timeout);
            return CreateLegitStoreData(context, state._sessionItems, state._staticObjects, state._timeout);
        }

        public override SessionStateStoreData GetItem(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actionFlags)
        {
            return this.DoGet(context, id, false, out locked, out lockAge, out lockId, out actionFlags);
        }

        public override SessionStateStoreData GetItemExclusive(HttpContext context, string id, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actionFlags)
        {
            return this.DoGet(context, id, true, out locked, out lockAge, out lockId, out actionFlags);
        }

        public override void SetAndReleaseItemExclusive(HttpContext context, string id, SessionStateStoreData item, object lockId, bool newItem)
        {
            ISessionStateItemCollection sessionItems = null;
            HttpStaticObjectsCollection staticObjects = null;

            if (item.Items.Count > 0)
                sessionItems = item.Items;
            if (!item.StaticObjects.NeverAccessed)
                staticObjects = item.StaticObjects;

            RedisSessionState state2 = new RedisSessionState(sessionItems, staticObjects, item.Timeout);

            RedisBase.Item_Set<string>(id, state2.ToJson(), item.Timeout);
        }

        #region "未实现方法"

        public override void Dispose()
        {
            
        }

        public override void EndRequest(HttpContext context)
        {
            
        }

        public override void InitializeRequest(HttpContext context)
        {
            
        }

        public override void ReleaseItemExclusive(HttpContext context, string id, object lockId)
        {
        }

        public override void RemoveItem(HttpContext context, string id, object lockId, SessionStateStoreData item)
        {
            RedisBase.Item_Remove(id);
        }

        public override void ResetItemTimeout(HttpContext context, string id)
        {
            
        }

        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return true;
        }

        #endregion

    }
    internal sealed class SessionStateItem
    {
        public Dictionary<string, object> Dict;
        public int Timeout;
    }

    internal sealed class RedisSessionState
    {
        internal ISessionStateItemCollection _sessionItems;
        internal HttpStaticObjectsCollection _staticObjects;
        internal int _timeout;

        internal RedisSessionState(ISessionStateItemCollection sessionItems, HttpStaticObjectsCollection staticObjects, int timeout)
        {
            this.Copy(sessionItems, staticObjects, timeout);
        }

        internal void Copy(ISessionStateItemCollection sessionItems, HttpStaticObjectsCollection staticObjects, int timeout)
        {
            this._sessionItems = sessionItems;
            this._staticObjects = staticObjects;
            this._timeout = timeout;
        }

        public string ToJson()
        {
            // 这里忽略_staticObjects这个成员。

            if (_sessionItems == null || _sessionItems.Count == 0)
            {
                return null;
            }

            Dictionary<string, object> dict = new Dictionary<string, object>(_sessionItems.Count);

            string key;
            NameObjectCollectionBase.KeysCollection keys = _sessionItems.Keys;
            for (int i = 0; i < keys.Count; i++)
            {
                key = keys[i];
                dict.Add(key, _sessionItems[key]);
            }

            SessionStateItem item = new SessionStateItem { Dict = dict, Timeout = this._timeout };

            return JsonConvert.SerializeObject(item);
        }

        public static RedisSessionState FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            try
            {
                SessionStateItem item = JsonConvert.DeserializeObject<SessionStateItem>(json);

                SessionStateItemCollection collections = new SessionStateItemCollection();

                foreach (KeyValuePair<string, object> kvp in item.Dict)
                {
                    collections[kvp.Key] = kvp.Value;
                }

                return new RedisSessionState(collections, null, item.Timeout);
            }
            catch
            {
                return null;
            }
        }
    }
}