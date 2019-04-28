import BasicMsg from '../views/User/BasicMsg';
import User from '../views/User/User';
import Order from '../views/User/Order/OrdersListHolder'; 

export default [{
  path: "/Customer", 
  component: User,
  children: [{
    path: "Basic",
    component: BasicMsg
  }, {
    path: "Order",
    component: Order
  }]
}]