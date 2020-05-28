require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');
import { RouterConfiguration, Router } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';

export class App {
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router): void {
    this.router = router;
    config.title = 'Aurelia';
    config.map([
      {
        route: ['', 'home'], name: 'home',
        moduleId: PLATFORM.moduleName('./components/home/home'), nav: true, title: 'Home'
      },
      {
        route: 'persons', name: 'persons',
        moduleId: PLATFORM.moduleName('./components/persons/persons'), nav: true, title: 'Persons'
      },
      {
        route: 'personAdd', name: 'personAdd',
        moduleId: PLATFORM.moduleName('./components/persons/person-add/personAdd')
      },
      {
        route: 'personEdit/:id', name: 'personEdit',
        moduleId: PLATFORM.moduleName('./components/persons/person-edit/personEdit')
      }

    ]);
  }
}
