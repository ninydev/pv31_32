import { Injectable } from '@nestjs/common';
import { CatModel } from './entities/CatModel';
import { CatsRepository } from './repository/cats.repository';
import {CreateCatDto} from "./dto/create-cat.dto";

@Injectable()
export class CatsService {
  constructor(private readonly catsRepository: CatsRepository) {}

  create(cat: CreateCatDto): CatModel {
    return this.catsRepository.create(cat);
  }

  findAll(params?: Record<string, any>): CatModel[] {
    return this.catsRepository.findAll(params);
  }

  findOne(id: number): CatModel | undefined {
    return this.catsRepository.findOne(id);
  }

  update(id: number, cat: Partial<CatModel>): CatModel | undefined {
    return this.catsRepository.update(id, cat);
  }

  remove(id: number): boolean {
    return this.catsRepository.remove(id);
  }
}
