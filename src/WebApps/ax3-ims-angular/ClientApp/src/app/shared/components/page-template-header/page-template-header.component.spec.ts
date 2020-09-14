import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageTemplateHeaderComponent } from './page-template-header.component';

describe('PageTemplateHeaderComponent', () => {
  let component: PageTemplateHeaderComponent;
  let fixture: ComponentFixture<PageTemplateHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageTemplateHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageTemplateHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
