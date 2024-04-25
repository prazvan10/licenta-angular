import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfPetitionsComponent } from './list-of-petitions.component';

describe('ListOfPetitionsComponent', () => {
  let component: ListOfPetitionsComponent;
  let fixture: ComponentFixture<ListOfPetitionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListOfPetitionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListOfPetitionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
