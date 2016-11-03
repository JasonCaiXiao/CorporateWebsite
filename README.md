写在前面：本人才疏学浅，不敢妄自菲薄，对代码或者设计有任何建议的同学可以联系本人QQ:806772835

1.本项目是一个通用的基本企业后台管理框架,基础类库已经搭建完成

2.基于本人对DDD领域设计的理解，同时结合MVC5、EF6CodeFirst、Bootstrap3开发

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
 
 客户端采用响应式布局，适配PC端及移动终端
 
 使用基于Bootstrap3开发的前端模板AdminLTE，github地址：https://github.com/almasaeed2010/AdminLTE 

3.目前正在做:实现分布式log日志的功能

4.下一步计划：  
  a.将加入Redis更好的解决多并发（支持分布式集群）
  b.ORM框架加入Dapper
  c.数据库采用MyCat进行读写分离（支持分布式集群）
  
