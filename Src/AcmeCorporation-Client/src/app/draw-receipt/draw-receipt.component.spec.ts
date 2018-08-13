import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrawReceiptComponent } from './draw-receipt.component';

describe('DrawReceiptComponent', () => {
  let component: DrawReceiptComponent;
  let fixture: ComponentFixture<DrawReceiptComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrawReceiptComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrawReceiptComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
