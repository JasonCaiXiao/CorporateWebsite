using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CorporateWebsite.Domain;
using CorporateWebsite.Domain.IRepositories;

namespace CorporateWebsite.Application.Services
{
    public abstract class ApplicationService
    {
        protected IUnitOfWork RepositorytContext { get; }
        protected ApplicationService(IUnitOfWork repositoryContext)
        {
            RepositorytContext = repositoryContext;
        }

        // 处理简单的聚合创建逻辑。
        protected TDtoList PerformCreateObjects<TDtoList, TDto, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Action<TDto> processDto = null,
            Action<TAggregateRoot> processAggregateRoot = null)
            where TDtoList : List<TDto>, new() where TAggregateRoot : class, IAggregateRoot
        {  
            TDtoList result = new TDtoList();
            if (dataTransferObjects.Count <= 0) return result;
            var ars = new List<TAggregateRoot>();
            foreach (var dto in dataTransferObjects)
            {
                if (processDto != null)
                    processDto(dto);
                var ar = Mapper.Map<TDto, TAggregateRoot>(dto);
                if (processAggregateRoot != null)
                    processAggregateRoot(ar);
                ars.Add(ar);
                repository.Create(ar);
            }
            RepositorytContext.Commit();
            ars.ForEach(ar => result.Add(Mapper.Map<TAggregateRoot, TDto>(ar)));
            return result;
        }

        // 处理简单的聚合更新操作。
        protected TDtoList PerformUpdateObjects<TDtoList, TDataObject, TAggregateRoot>(TDtoList dataTransferObjects,
            IRepository<TAggregateRoot> repository,
            Func<TDataObject, int> idFunc,
            Action<TAggregateRoot, TDataObject> updateAction)
            where TDtoList : List<TDataObject>, new()
            where TAggregateRoot : class, IAggregateRoot
        {   
            TDtoList result = null;
            if (dataTransferObjects.Count > 0)
            {
                result = new TDtoList();
                foreach (var dto in dataTransferObjects)
                {
                    var id = idFunc(dto);
                    var ar = repository.Single(id);
                    updateAction(ar, dto);
                    repository.Update(ar);
                    result.Add(Mapper.Map<TAggregateRoot, TDataObject>(ar));
                }

                RepositorytContext.Commit();
            }
            return result;
        }

        // 处理简单的删除聚合根的操作。
        protected void PerformDeleteObjects<TAggregateRoot>(IList<int> ids, IRepository<TAggregateRoot> repository, Action<int> preDelete = null, Action<int> postDelete = null)
            where TAggregateRoot : class, IAggregateRoot
        {  
            foreach (var id in ids)
            { 
                if (preDelete != null)
                    preDelete(id);
                var ar = repository.Single(id);
                repository.Delete(ar);
                if (postDelete != null)
                    postDelete(id);
            }
            RepositorytContext.Commit();
        }

    }
}
