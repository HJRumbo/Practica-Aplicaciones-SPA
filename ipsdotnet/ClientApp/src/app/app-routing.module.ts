import { DatosRegistroComponent } from './copago/datos-registro/datos-registro.component';
import { DatosConsultaComponent } from './copago/datos-consulta/datos-consulta.component';
import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule} from '@angular/router';


const routes:  Routes = [
  {
    path: 'datosRegistro',
    component: DatosRegistroComponent

  },

  {
    path: 'datosConsulta',
    component: DatosConsultaComponent

  }

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
