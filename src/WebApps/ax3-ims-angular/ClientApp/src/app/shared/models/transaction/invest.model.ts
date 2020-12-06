export interface InvestModel {
  accountId: string;
  accountName: string;
  transactionTypeId: number;
  transactionDate: Date;
  rate: number;
  amount: number;
  balance: number;
  description: string;
}
