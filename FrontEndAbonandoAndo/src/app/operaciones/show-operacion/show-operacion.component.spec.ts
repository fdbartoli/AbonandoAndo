import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowOperacionComponent } from './show-operacion.component';

describe('ShowOperacionComponent', () => {
  let component: ShowOperacionComponent;
  let fixture: ComponentFixture<ShowOperacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowOperacionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowOperacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
