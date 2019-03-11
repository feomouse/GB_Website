import CustomerSignIn from '../views/SignIn/CustomerSignIn';
import MerchantSignIn from '../views/SignIn/MerchantSignIn';

export default [{
  path: "/Customer/SignIn", component: CustomerSignIn
}, {
  path: "/Merchant/SignIn", component: MerchantSignIn
}]