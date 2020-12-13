export interface BuySellModel {
  sourceAccountId: string;
  sourceAccountName: string;
  investmentToolTypeId: number;
  investmentToolTypeName: string;
  investmentToolId: string;
  investmentToolName: string;
  transactionDate: Date;
  rate: number;
  amount: number;
  balance: number;
  destinationAccountId: string;
  destinationAccountName: string;
  description: string;
}
