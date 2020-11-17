import {Component, OnChanges, Output, EventEmitter, Input} from '@angular/core';
import {DxDataGridComponent} from 'devextreme-angular';

@Component({
  selector: 'app-page-template-header',
  templateUrl: './page-template-header.component.html',
  styleUrls: ['./page-template-header.component.scss']
})
export class PageTemplateHeaderComponent implements OnChanges {
  @Input() dataGrid: DxDataGridComponent;
  @Output() add = new EventEmitter();
  @Output() refresh = new EventEmitter();
  @Output() edit = new EventEmitter();
  @Output() delete = new EventEmitter();
  @Output() view = new EventEmitter();
  @Output() filter = new EventEmitter();
  @Output() print = new EventEmitter();
  @Output() download = new EventEmitter();
  @Output() expandAll = new EventEmitter();
  isGroupPanelEnabled = false;

  constructor() { }

  ngOnChanges(): void {
  }

  addClicked() {
    this.add.emit();
  }
  refreshClicked() {
    if(this.dataGrid) {
      this.dataGrid.instance.getDataSource().reload();
    }
  }
  editClicked() {
    this.edit.emit();
  }
  deleteClicked() {
    this.delete.emit();
  }
  viewClicked() {
    this.view.emit();
  }
  filterClicked() {
    this.filter.emit();
  }
  printClicked() {
    this.filter.emit();
  }
  downloadClicked() {
    this.download.emit();
  }
  expandAllClicked() {
    this.download.emit();
  }
  changeOption(optionString: string) {
    if (this.dataGrid) {
      this.dataGrid.instance.option(optionString, !this.dataGrid.instance.option(optionString));
    }
    this.isGroupPanelEnabled = false;
    if (optionString === 'groupPanel.visible' && this.dataGrid.groupPanel.visible) {
      this.isGroupPanelEnabled = true;
    }
  }
}
