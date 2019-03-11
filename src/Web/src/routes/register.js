import CustomerSignUp from '../views/SignUp/CustomerSignUp';
import MerchantSignUp from '../views/SignUp/MerchantSignUp';

export default [{
    path: "/Customer/SignUp",
    name: "customerSignUp",
    component: CustomerSignUp
  },{
    path: "/Merchant/SignUp",
    name: "merchantSignUp",
    component: MerchantSignUp
}]