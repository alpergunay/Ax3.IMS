import {IAddModel} from '../iadd-model';

export interface AccountAddModel extends IAddModel {
  userId: string;
  storeBranchId: string;
  accountTypeId: string;
  investmentToolId: string;
  accountNo: string;
}
