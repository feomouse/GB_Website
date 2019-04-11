import CreateShop from '../views/Merchant/CreateShop';
import Operation from '../views/Merchant/Operation';
import CreateIdentity from '../views/Merchant/CreateIdentity';
import EditShop from '../views/Merchant/Shop/EditShop';
import GBProductOperations from '../views/Merchant/GBProduct/GBProductOperations';

export default [{
  path : '/Merchant/CreateShop', component: CreateShop
}, {
  path: '/Merchant/Operation',
  component: Operation,
  children: [{
    path: 'EditShop',
    component: EditShop
  }, {
    path: 'GBProductOperations',
    component: GBProductOperations
  }]
}, {
  path : '/Merchant/CreateIdentity', component: CreateIdentity
}]