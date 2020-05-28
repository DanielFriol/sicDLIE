import { ValidationRules } from 'aurelia-validation'
import { autoinject } from 'aurelia-dependency-injection';
import { inject, NewInstance } from 'aurelia-dependency-injection';
import { ValidationControllerFactory } from 'aurelia-validation';
import { Validator } from 'aurelia-validation';
import {RouterConfiguration, Router} from 'aurelia-router';
import { observable } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import {Redirect} from 'aurelia-router';



let httpClient = new HttpClient();


@inject(ValidationControllerFactory)
@inject(Router)
export class PersonAdd {

    @observable personBind: PersonModelAdd;
    controller = null;
    changed: boolean = true;
    aurilia: any;
    constructor(ValidationControllerFactory, router: Router) {
        this.configHttpClient();
        this.controller = ValidationControllerFactory.createForCurrentScope();
        this.controller.validate();

    }


    submitPerson(){
        httpClient
        .fetch('Person',{ method: 'POST', body: JSON.stringify(this.personBind)})
        .then(response => response.json())
        .then(data => {
            console.log(data);
            this.reset();
        })
        .catch(error => {
            alert('Error posting persons!');
        });
    }
    goBackToPerson(){
    //    this.router.navigateToRoute('Person');
    }
    configHttpClient(){
        httpClient.configure(config => {
           config
               .withBaseUrl('http://localhost:52027/api/v1/')
               .withDefaults({
                   credentials: 'same-origin',
                   headers: {
                       'Accept': 'application/json',
                       'X-Requested-With': 'Fetch'
                   }
               })
               .withInterceptor({
                   request(request) {
                       console.log(`Requesting ${request.method} ${request.url}`);
                       return request;
                   },
                   response(response) {
                       console.log(`Received ${response.status} ${response.url}`);
                       return response;
                   }
               });
       });
     }

    reset(){
        this.changed = true;
        this.personBind = new PersonModelAdd();
    }

    personBindChanged(newValue, oldValue) {
        this.changed=false;
        if (this.personBind) {
            ValidationRules
                .ensure('name').required().minLength(5).maxLength(60)
                .ensure('familyName').required().minLength(5).maxLength(80)
                .ensure('address').required().minLength(10).maxLength(200)
                .ensure('countryOfOrigin').required()
                .ensure('emailAdress').required().email()
                .ensure('age').required().min(20).max(60)
                .ensure('hired').required()
                .on(this.personBind);
            this.controller.validate();
        }
    }
}


export class PersonModelAdd {
    id: number;
    name: string;
    familyName: string;
    address: string;
    countryOfOrigin: string;
    emailAdress: string;
    age: number;
    hired: boolean;
}