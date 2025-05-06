import { Routes } from '@angular/router';
import { VoyagesComponent } from './voyages/voyages.component';
import { CountriesComponent } from './countries/countries.component';
import { PortsComponent } from './ports/ports.component';
import { ShipsComponent } from './ships/ships.component';

export const routes: Routes = [
    {path: 'ships', component: ShipsComponent},
    {path: 'countries', component: PortsComponent},
    {path: 'voyages', component: VoyagesComponent},
    {path: 'countries', component: CountriesComponent},
];
