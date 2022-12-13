import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Person } from 'src/app/models/Person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent {
  @Input() person?:Person;
  @Output() personsUpdated = new EventEmitter<Person[]>();

  constructor(private personService:PersonService){
    
  }
  ngOnInit():void{
  }
  updatePerson(person:Person){
    this.personService.updatePerson(person)
    .subscribe((persons:Person[])=>this.personsUpdated.emit(persons));
  }
  
  deletePerson(person:Person){
    this.personService.deletePersons(person)
    .subscribe((persons:Person[])=>this.personsUpdated.emit(persons));
  }
  
  createPerson(person:Person){

    this.personService.createPerson(person)
    .subscribe((persons:Person[])=>this.personsUpdated.emit(persons));
    console.log(person);
  }
}
