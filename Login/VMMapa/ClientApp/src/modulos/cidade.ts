import { FronteirasCidade } from "./fronteirascidade";

export class Cidade {
  codigo: number;
  nome: string;
  habitantes: number;
  sequencia: number;
  fronteirasCidade: [FronteirasCidade];
}
