require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

import { HttpClient, json } from 'aurelia-fetch-client';
import {DialogService} from 'aurelia-dialog';
import {inject} from 'aurelia-framework';
import {Prompt} from '../modal/delete-modal';

let httpClient = new HttpClient();

@inject(DialogService)

export class Person {
    public Persons : any[] = [];
    constructor(private dialogService : DialogService){
        this.configHttpClient();
        this.getAllPersons();
        this.dialogService = dialogService;
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
    
    public getAllPersons() {
        httpClient
            .fetch('Person')
            .then(response => response.json())
            .then(data => {
                this.Persons = data;
            })
            .catch(error => {
                alert('Error when getting persons!');
            });
    }

    openModal(person) {
        this.dialogService.open( {viewModel: Prompt, model: `Are you sure you want to delete '${person.name}' ?` }).whenClosed(response => {
           if (!response.wasCancelled) {
              console.log('OK');
              this.deletePerson(person.id);
           } else {
              console.log('cancelled');
           }
        });
     }

     public deletePerson(id){
        httpClient
            .fetch(`Person/${id}`, {
                method: "DELETE"
            })
            .then(data => {
                if(data.ok)
                    this.getAllPersons();
               
            }).catch(error => {
                alert('Error when deleting persons!');
            });;
     }
}