import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EncuestaManipuladorComponent } from './encuesta-manipulador.component';

describe('EncuestaManipuladorComponent', () => {
  let component: EncuestaManipuladorComponent;
  let fixture: ComponentFixture<EncuestaManipuladorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EncuestaManipuladorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EncuestaManipuladorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
