import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditPlayersComponent } from './add-edit-player.component';

describe('AddEditPlayersComponent', () => {
  let component: AddEditPlayersComponent;
  let fixture: ComponentFixture<AddEditPlayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddEditPlayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditPlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
