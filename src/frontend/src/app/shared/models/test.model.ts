export interface LaboratoryTest {
  testId: string;
  sampleId: string;
  testType: string;
  measurementValue: number;
  createdAt: string;
}

export interface CreateTestRequest {
  sampleId: string;
  testType: string;
  measurementValue: number;
}

export interface UpdateTestRequest {
  measurementValue: number;
}
