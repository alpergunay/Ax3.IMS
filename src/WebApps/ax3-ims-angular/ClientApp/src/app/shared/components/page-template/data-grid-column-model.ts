export class DataGridColumnModel {
  dataField: string;
  caption: string;
  dataType?: string;
  format?: string;
  cellTemplate?: any;
  calculateCellValue?: Function;
  customizeText?: Function;
  summary?: string;
  groupIndex?: number;
  calculateFilterExpression?: Function;
  visible?: boolean;
  filterValues?: Array<any> = [];
  visibleIndex?: number;
  width?: number;
}
