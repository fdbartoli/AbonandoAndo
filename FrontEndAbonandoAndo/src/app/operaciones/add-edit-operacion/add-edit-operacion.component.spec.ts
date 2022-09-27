import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditOperacionComponent } from './add-edit-operacion.component';

describe('AddEditOperacionComponent', () => {
  let component: AddEditOperacionComponent;
  let fixture: ComponentFixture<AddEditOperacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditOperacionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditOperacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
