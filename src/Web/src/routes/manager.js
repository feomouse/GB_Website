import Operation from '../views/Manager/Operation';
import IdentityList from '../views/Manager/CheckIdentityManage/IdentityList';
import IdentityDetail from '../views/Manager/CheckIdentityManage/IdentityDetail';
import VioTab from '../views/Manager/ViolateManage/VioTab';
import ShopType from '../views/Manager/SetShopType';

export default [{
  path: "/Manager",
  component: Operation,
  children: [{
    path: "IdentityList",
    component: IdentityList
  }, {
    path: "IdentityDetail",
    component: IdentityDetail
  },{
    path: "ViolateManager",
    component: VioTab
  }, {
    path: 'SetShopType',
    component: ShopType
  }]
}]