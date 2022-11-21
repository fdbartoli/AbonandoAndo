import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEgresoComponent } from './add-egreso.component';

describe('AddEgresoComponent', () => {
  let component: AddEgresoComponent;
  let fixture: ComponentFixture<AddEgresoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEgresoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEgresoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
