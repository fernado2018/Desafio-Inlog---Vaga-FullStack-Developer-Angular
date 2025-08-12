import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { PagedResult } from '@app/models/Paginacao/PagedResult';
import { TipoVeiculo } from '@app/utils/tipoVeiculos';

@Component({
  selector: 'app-table-pages',
  templateUrl: './table-pages.component.html',
  styleUrl: './table-pages.component.scss',
})
export class TablePagesComponent<T extends { [key: string]: any }>
  implements AfterViewInit
{
  @Input() columns: string[] = [];
  @Input() displayedColumns: { key: string; label: string }[] = [];
  @Input() data!: PagedResult<T>;
  @Input() pageSizeOptions: number[] = [5, 10, 25, 50];

  dataSource = new MatTableDataSource<T>();
  @Output() view = new EventEmitter<any>();
  @Input() acoes: { tipo: string; icone: string; tooltip?: string }[] = [];
  @Output() abrirTelaCadastro = new EventEmitter<void>();
  @Output() pageSizeOptionsChange = new EventEmitter<number>();
  pageSize: number = 5;

  @Output() pageSizeChange = new EventEmitter<number>();
  @Output() filtroChange = new EventEmitter<string>();
  @Output() paginacaoChange = new EventEmitter<any>();

  filterValue = '';
  pageIndex: number = 0;
  tipoVeiculo = TipoVeiculo;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {}

  ngAfterViewInit() {
    this.paginator.page.subscribe((event) => {
      this.pageSizeOptionsChange.emit(event.pageSize);
    });
  }

  onPageEvent(event: PageEvent) {
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.pageIndex = this.pageIndex + 1;
    const pag = {
      pageSize: this.pageSize,
      pageIndex: this.pageIndex,
    };
    this.paginacaoChange.emit(pag);
  }

  filtrar(event: Event) {
    const filterInput = (event.target as HTMLInputElement).value;
    this.filterValue = filterInput;

    this.filtroChange.emit(filterInput);
  }

  getColumnKey(key: keyof T): string {
    return key.toString();
  }

  getCellValue(element: any, key: string): string {
    const value = element[key];

    if (typeof value === 'object' && value !== null) {
      return JSON.stringify(value);
    }

    return value ?? '';
  }

  onView(element: any): void {
    this.view.emit(element);
  }

  emitirTelaCadastro() {
    this.abrirTelaCadastro.emit();
  }

  ngOnChanges(changes: SimpleChanges): void {
    let result: any;
    if (this.data) result = this.data.results;
    this.dataSource = new MatTableDataSource<T>(result);
    this.dataSource.filterPredicate = (data: T, filter: string) => {
      const dataStr = Object.values(data).join(' ').toLowerCase();
      return dataStr.includes(filter.trim().toLowerCase());
    };

    if (!this.displayedColumns || this.displayedColumns.length === 0) {
      this.displayedColumns = this.gerarColunasComRotulo(result);
    }

    this.dataSource.filterPredicate = (data: T, filter: string) => {
      const dataStr = Object.values(data).join(' ').toLowerCase();
      return dataStr.includes(filter.trim().toLowerCase());
    };

    if (changes['pageSizeOptions'] && this.pageSizeOptions.length > 0) {
      this.pageSize = this.pageSizeOptions[0];
      this.pageSizeChange.emit(this.pageSize);
    }
  }

  gerarColunasComRotulo(data: T[]): { key: string; label: string }[] {
    if (!data || data.length === 0) return [];

    const exemplo = data[0];
    const chaves = Object.keys(exemplo);

    const colunas = chaves.map((key) => ({
      key,
      label: this.formatarLabel(key),
    }));

    if (this.acoes && this.acoes.length > 0) {
      colunas.push({ key: 'acoes', label: 'Ações' });
    }

    return colunas;
  }

  formatarLabel(key: string): string {
    return key
      .replace(/([A-Z])/g, ' $1')
      .replace(/^./, (str) => str.toUpperCase());
  }

  getrowCount(): number {
    if (this.data) return this.data.rowCount;
    return 0;
  }

  limparFiltro() {
  this.filterValue = '';
  this.filtrar(new Event('input'));
}

}
