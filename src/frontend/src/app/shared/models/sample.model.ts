export interface Sample {
  sampleId: string;
  mixtureId: string;
  sampleNumber: string;
  productionDate: string;
}

export interface CreateSampleRequest {
  mixtureId: string;
  sampleNumber: string;
  productionDate: string;
}

export interface UpdateSampleRequest {
  sampleNumber: string;
}
