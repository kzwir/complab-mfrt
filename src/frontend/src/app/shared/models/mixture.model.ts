export interface Mixture {
  mixtureId: string;
  code: string;
  polymerPercent: number;
  quartzitePercent: number;
}

export interface CreateMixtureRequest {
  code: string;
  polymerPercent: number;
  quartzitePercent: number;
}

export interface UpdateMixtureRequest {
  polymerPercent: number;
  quartzitePercent: number;
}
