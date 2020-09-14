import {Component, EventEmitter, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-page-template',
  templateUrl: './page-template.component.html',
  styleUrls: ['./page-template.component.scss']
})
export class PageTemplateComponent implements OnInit {
  @Output() addButton = new EventEmitter();
  @Output() refreshButton = new EventEmitter();
  @Output() editButton = new EventEmitter();
  @Output() deleteButton = new EventEmitter();
  @Output() viewButton = new EventEmitter();
  @Output() filterButton = new EventEmitter();
  @Output() printButton = new EventEmitter();
  @Output() downloadButton = new EventEmitter();
  @Output() expandAllButton = new EventEmitter();
  filter: any;
  gridFilterValue: any;
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
    this.editButton.emit();
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
    this.expandAllButton.emit();
  }
  gridFilterValueChange(event) {
    this.filter = event;
    this.gridFilterValue = event;
  }
}
