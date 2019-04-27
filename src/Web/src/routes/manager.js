import Operation from '../views/Manager/Operation';
import IdentityList from '../views/Manager/CheckIdentityManage/IdentityList';
import IdentityDetail from '../views/Manager/CheckIdentityManage/IdentityDetail';
import ViolateManage from '../views/Manager/ViolateManage/ViolateManage';
import ViolateList from '../views/Manager/ViolateManage/ViolateList';
import IsWarnedList from '../views/Manager/ViolateManage/IsWarnedList';
import IsInBlackMenu from '../views/Manager/ViolateManage/IsInBlackMenu';

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
    component: ViolateManage
  }]
}]