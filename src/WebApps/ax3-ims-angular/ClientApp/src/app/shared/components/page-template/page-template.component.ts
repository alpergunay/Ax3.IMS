import {Component, EventEmitter, Input, OnInit, Output, ViewChild} from '@angular/core';
import {DataGridColumnModel} from './data-grid-column-model';
import {DxDataGridComponent} from 'devextreme-angular';
import {RemoteOperationsModel} from "./remote-operations.model";

@Component({
  selector: 'app-page-template',
  templateUrl: './page-template.component.html',
  styleUrls: ['./page-template.component.scss']
})
export class PageTemplateComponent implements OnInit {
  @Input() ComponentName = '';
  @Input() DataSource: any = {};
  @Input() Columns: DataGridColumnModel[] = [];
  @Input() AllowSelection = true;
  @Input() SingleSelectionMode = false;
  @Output() addButton = new EventEmitter();
  @Output() refreshButton = new EventEmitter();
  @Output() editButton = new EventEmitter();
  @Output() deleteButton = new EventEmitter();
  @Output() viewButton = new EventEmitter();
  @Output() filterButton = new EventEmitter();
  @Output() printButton = new EventEmitter();
  @Output() downloadButton = new EventEmitter();
  @Output() expandAllButton = new EventEmitter();
  @Output() selectionChange = new EventEmitter<any>();
  @Output() doubleClickRow = new EventEmitter<any>();
  @Output() onDataGridContentReady = new EventEmitter();
  filter: any;
  gridFilterValue: any;
  isEditAndDeleteButtonDisabled = true;
  ModalParameter: { SelectedRowId } = { SelectedRowId: 0 };
  manageAutoExpandAll = false;
  @Input() IsPreview = false;
  @Input() RemoteOperations: RemoteOperationsModel = <RemoteOperationsModel>{
    enable: false,
    paging: false,
    scrollingMode: 'infinite'
  };
  @ViewChild('grid') DataGrid: DxDataGridComponent;
  constructor() { }

  ngOnInit(): void {
  }
  addButtonClicked() {
    this.addButton.emit();
  }
  refreshButtonClicked() {
    this.refreshButton.emit();
  }
  editButtonClicked() {
    this.editButton.emit(this.ModalParameter);
  }
  deleteButtonClicked() {
    this.deleteButton.emit();
  }
  viewButtonClicked() {
    this.viewButton.emit();
  }
  filterButtonClicked() {
    this.filterButton.emit();
  }
  printButtonClicked() {
    this.printButton.emit();
  }
  downloadButtonClicked() {
    this.downloadButton.emit();
  }
  expandAllButtonClicked() {
    if (this.manageAutoExpandAll) {
      this.manageAutoExpandAll = false;
    } else {
      this.manageAutoExpandAll = true;
    }
  }
  gridFilterValueChange(event) {
    this.filter = event;
    this.gridFilterValue = event;
  }
  gridSelectionChanged(event) {
    this.isEditAndDeleteButtonDisabled = event.selectedRowKeys.length !== 1;
    if (this.isEditAndDeleteButtonDisabled === false) {
      if (event.selectedRowKeys[0].id != null) {
        this.ModalParameter.SelectedRowId = event.selectedRowKeys[0].id;
      } else if (event.selectedRowKeys[0].uId != null) {
        this.ModalParameter.SelectedRowId = event.selectedRowKeys[0].uId;
      } else if (event.selectedRowsData[0].id != null) {
        this.ModalParameter.SelectedRowId = event.selectedRowsData[0].id;
      }
    } else {
      this.ModalParameter.SelectedRowId = 0;
    }
    this.selectionChange.emit(event);
  }
  gridDoubleClicked (event) {
    const component = event.component,
      prevClickTime = component.lastClickTime;
    component.lastClickTime = new Date();
    if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
      if (this.IsPreview !== true && this.isEditAndDeleteButtonDisabled !== true) {
        this.editButton.emit(this.ModalParameter);
      } else  {
        this.viewButton.emit(this.ModalParameter);
      }
    }
  }
  gridRowClicked(e) {
    if (e.rowType === 'group') {
      if (e.isExpanded) {
        e.component.collapseRow(e.key);
      } else {
        e.component.expandRow(e.key);
      }
    }
  }
  onGridContentReady(e) {
    const grid = e.component;
    const selectedKeys = grid.getSelectedRowKeys();
    for (let i = 0; i < selectedKeys.length; i++) {
      if (grid.getRowIndexByKey(selectedKeys[i]) < 0) {
        grid.deselectRows([selectedKeys[i]]);
      }
    }
    this.onDataGridContentReady.emit();
  }
}
