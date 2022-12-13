import { Component } from '@angular/core';
import { Person } from './models/Person';
import { PersonService } from './services/person.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Hahn.UI';
  persons: Person[]=[];
  personToEdit? : Person;
  constructor(private personService : PersonService){}

  ngOnInit():void{
    this.personService
    .getPersons()
    .subscribe((result:Person[])=>{
      this.persons=result;
      console.log(this.persons);
    });
  }

  updatePersonList(persons:Person[]){
    this.persons = persons;
  }

  initNewPerson(){
    this.personToEdit = new Person();
  }

  editPerson(person:Person){
      this.personToEdit = person;
  }
}
