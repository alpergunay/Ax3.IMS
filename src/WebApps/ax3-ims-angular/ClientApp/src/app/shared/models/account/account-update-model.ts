import {IUpdateModel} from '../iupdate-model';

export interface AccountUpdateModel extends IUpdateModel {
  userId: string;
  storeBranchId: string;
  accountTypeId: string;
  investmentToolId: string;
  accountNo: string;
}
