写在前面：小弟才疏学浅水平有限,对代码或者设计有任何建议的同学可以联系本人QQ:806772835

更新日志：
2016-11-19： 

a.已加入Redis作为缓存类的基础性代码,若要使用redis解决多并发需要亲们各自编写对应代码,redis集群的配置和主从切换等操作可以自行学习

b.已加入rabbit队列机制,选择此队列很大部分是提供了一个简洁的管理界面供开发人员查看和设置队列

c.考虑到项目性质差异，并未加入分布式log组件ExceptionLess相关代码,有兴趣的亲们可以自行学习，个人建议在本地部署一套，默认采用的是elasticsearch进行数据的存储，可以修改为数据库和redis进行存储数据,也可以结合log4net进行使用

1.本项目是一个通用的基本企业后台管理(MVC5)、WebAPi框架,基础类库已经搭建完成

2.基于本人对DDD领域设计的理解

 同步异步使用await、async;线程使用Task
 
 支持多种数据库嵌入：mysql、sqlserver等
 
 服务端采用Ioc容器Autofac对各层解耦
 
 使用Entityframework.extended插件对EF进行扩展，使其更好支持批量操作
 
 使用dynamic linq 对集合进行动态操作
 
 使用表达式树编写ExpressionExtension，可以对表达式进行任何的组装
 
 使用AutoMap进行实体类之间的映射
 
 使用AOP技术对各接口执行进行过滤操作，从而实现给带有返回值方法配置缓存.以及事务机制
 
 封装各类常用的类库对文件（包含图片、XML）的操作
 
 封装各类加解密类库：CipherType.Des、CipherType.TripleDes、CipherType.Aes、MD5、Base64加解密
 
 如进行mvc5后台管理开发，建议采用响应式布局，适配PC端及移动终端，同时可以使用Bootstrap3开发的前端模板AdminLTE.推荐一个小插件：MiniProfiler计算  开发人员写EF语句时的性能，从而进行调优
  
 如进行WebApi开发，则在身份验证时候建议使用类似微信的token验证机制，外部可以使用outhor2.0.这里推荐一个插件Swagger.Net,可以模拟请求与提供在线文档
 
3.目前正在做:实现分布式log日志的功能（使用ExceptionLess组件）

4.下一步计划：  
  a.将加入Redis缓存、解决多并发（j持久化、主从配置、支持分布式集群）【redis使用一般两个场景】
  
  1.一个是读操作频繁则使用redis作为缓存,先数据从DB预加载部分数据至redis,访问某数据时先从redis中读取，如果没有则从db-查询再更新至redis
  
  2.另一个是大量写操作频繁则使用redis存储需要操作的数据，然后使用线程去处理更新至db
  
  b.将加入Rabbit消息队列机制（支持分布式集群）【路由分配、持久化等】
  
  c.数据库采用MyCat进行读写分离、一般采用主-主配置（支持分布式集群）【支持数据表的水平垂直分表】（在此仅提供一个参考不加入相应的代码，小弟只在一个项目中使用过）
  
