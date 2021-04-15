import { Injectable } from "@angular/core";
import { AbstractControl } from "@angular/forms";
import { Observable } from "rxjs";
import { map, startWith } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class Filtros {

    filterOptions(myControl: AbstractControl, lista: string[]) {
        return myControl.valueChanges
            .pipe(
                startWith(''),
                map(value => this._filter(value, lista))
            );
    }

    private _filter(value: string, lista: string[]): string[] {
        if (value == '' || value == undefined) return lista;
        return lista.filter(option => option.toLowerCase().includes(value.toLowerCase()));
    }
}

export class FilteredOptions {
    filteredPais: Observable<string[]>;
    filteredSexo: Observable<string[]>;
    filteredNivelAcademico: Observable<string[]>;
    filteredEstadoCivil: Observable<string[]>;
}