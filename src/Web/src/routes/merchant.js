import CreateShop from '../views/Merchant/CreateShop';
import Operation from '../views/Merchant/Operation';
import CreateIdentity from '../views/Merchant/CreateIdentity';
import EditShop from '../views/Merchant/Shop/EditShop';
import GBProductOperations from '../views/Merchant/GBProduct/GBProductOperations';
import ApplyGBService from '../views/Merchant/GBProduct/ApplyGBService';
import GBServiceContract from '../views/Merchant/GBProduct/GBServiceContract';
import WelcomePage from '../views/Merchant/WelcomePage';
import Data from '../views/Merchant/Data/Data';

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
  }, {
    path: 'GBServiceApply',
    component: ApplyGBService
  }, {
    path: 'GBServiceContract',
    component: GBServiceContract
  }, {
    path: 'Welcome',
    component: WelcomePage
  }, {
    path: 'Data',
    component: Data
  }]
}, {
  path : '/Merchant/CreateIdentity', component: CreateIdentity
}]