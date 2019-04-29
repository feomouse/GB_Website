import CustomerSignUp from '../views/SignUp/CustomerSignUp';
import MerchantSignUp from '../views/SignUp/MerchantSignUp';
import ManagerSignUp from '../views/SignUp/ManagerSignUp';

export default [{
    path: "/Customer/SignUp",
    name: "customerSignUp",
    component: CustomerSignUp
  },{
    path: "/Merchant/SignUp",
    name: "merchantSignUp",
    component: MerchantSignUp
  },{
    path: "/Manager/SignUp",
    name: "managerSignUp",
    component: ManagerSignUp
  }]