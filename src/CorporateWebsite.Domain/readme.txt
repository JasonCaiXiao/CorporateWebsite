1.在Domain中定义各层的接口
2.Model为充血模型，例如Order类中必须有订单确认、处理发货等方法，这些方法通过Event事件去实现
3.Model创建数据库