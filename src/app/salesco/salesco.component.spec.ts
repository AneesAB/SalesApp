import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalescoComponent } from './salesco.component';

describe('SalescoComponent', () => {
  let component: SalescoComponent;
  let fixture: ComponentFixture<SalescoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalescoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalescoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
