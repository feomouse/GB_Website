import Operation from '../views/Manager/Operation';
import IdentityList from '../views/Manager/CheckIdentityManage/IdentityList';
import IdentityDetail from '../views/Manager/CheckIdentityManage/IdentityDetail';
import VioTab from '../views/Manager/ViolateManage/VioTab';

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
  }]
}]