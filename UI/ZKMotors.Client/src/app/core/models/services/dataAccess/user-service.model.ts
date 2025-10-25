export interface IUser{
  userId: number;
  firstName: string;
  lastName: string;
  userName: string;
  roles: IUserRole[];
  token: string;
}
export interface IUserRole{
  roleId: number;
  name: string;
}
export interface ILoginRequest{
  userName: string;
  password: string;
}
export interface IRegisterRequest{
  firstName: string;
  lastName: string;
  userName: string;
  password: string;
  confirmPassword: string;
  roleIds: number[];
}