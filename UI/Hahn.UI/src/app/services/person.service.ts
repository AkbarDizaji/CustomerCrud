import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Validator } from 'fluentvalidation-ts';
import { Observable } from 'rxjs';
import { Person } from '../models/Person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private baseUrl = "http://localhost:7158";
  private url = "Person"; 
  constructor(private http:HttpClient) { }
  public getPersons():Observable<Person[]>{
    return this.http.get<Person[]>(this.baseUrl+'/api/'+this.url);
  }

  
  public updatePerson(person:Person):Observable<Person[]>{
    let validator = new PersonValidator();
    validator.validate(person);
    return this.http.put<Person[]>(this.baseUrl+'/api/'+this.url+'/'+person.id,person);
  }
  
  
  public createPerson(person:Person):Observable<Person[]>{
    let validator = new PersonValidator();
    validator.validate(person);
    return this.http.post<Person[]>(this.baseUrl+'/api/'+this.url,person);
  }


  public deletePersons(person:Person):Observable<Person[]>{
    return this.http.delete<Person[]>(this.baseUrl+'/api/'+this.url+'/'+person.id);
  }

}

class PersonValidator extends Validator<Person> {
  constructor() {
    super();

    this.ruleFor('firstName')
      .notEmpty()
      .withMessage('Please enter your First Name.');
  
      this.ruleFor('firstName')
      .maxLength(100)
      .withMessage('First Name should be less than 100.');


      this.ruleFor('lastName')
      .notEmpty()
      .withMessage('Please enter your Last Name.');
  
      this.ruleFor('lastName')
      .maxLength(100)
      .withMessage('Last Name should be less than 100.');
  }
  }
