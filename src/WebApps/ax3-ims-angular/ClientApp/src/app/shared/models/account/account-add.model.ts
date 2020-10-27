import {BaseAddModel} from '../base-add.model';

export interface AccountAddModel extends BaseAddModel {
  userId: string;
  storeBranchId: string;
  accountTypeId: number;
  accountTypeName: string;
  investmentToolId: string;
  accountNo: string;
}
