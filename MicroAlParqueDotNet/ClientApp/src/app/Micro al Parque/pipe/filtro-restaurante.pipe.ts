import { Pipe, PipeTransform } from '@angular/core';
import { Restaurante } from '../Modelos/restaurante';

@Pipe({
  name: 'filtroProducto'
})
export class FiltroRestaurantePipe implements PipeTransform {

  transform(restaurantes: Restaurante[], filtroProducto: string): any {
    if (filtroProducto == null) return restaurantes;
         return restaurantes.filter(r => r.NIT.toLowerCase().indexOf(filtroProducto.toLowerCase()) !== -1
         || r.nombre.toLowerCase().indexOf(filtroProducto.toLowerCase()) !== -1
         || r.idPropietario.toLowerCase().indexOf(filtroProducto.toLowerCase()) !== -1);
      }    

}
