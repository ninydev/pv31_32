import {
  Controller,
  Get,
  Post,
  Body,
  Patch,
  Param,
  Delete,
  HttpCode,
  HttpStatus,
  NotFoundException,
  Query
} from '@nestjs/common';
import { CatsService } from './cats.service';
import { CreateCatDto } from './dto/create-cat.dto';
import { UpdateCatDto } from './dto/update-cat.dto';

@Controller('cats')
export class CatsController {
  constructor(private readonly catsService: CatsService) {}

  @Post()
  @HttpCode(HttpStatus.CREATED)
  create(@Body() createCatDto: CreateCatDto) {
    return this.catsService.create(createCatDto);
  }

  @Get()
  findAll(
      @Query('page') page: number = 1,
      @Query('limit') limit: number = 10,
      @Query('sortBy') sortBy: string = 'id',
      @Query('order') order: 'asc' | 'desc' = 'asc'
  ) {
    return this.catsService.findAll({ page, limit, sortBy, order });
  }

  @Get(':id')
  findOne(@Param('id') id: string) {
    const cat = this.catsService.findOne(+id);
    if (!cat) {
      throw new NotFoundException(`Cat with ID ${id} not found`);
    }
    return cat;
  }

  @Patch(':id')
  update(@Param('id') id: string, @Body() updateCatDto: UpdateCatDto) {
    const updatedCat = this.catsService.update(+id, updateCatDto);
    if (!updatedCat) {
      throw new NotFoundException(`Cat with ID ${id} not found`);
    }
    return updatedCat;
  }

  @Delete(':id')
  @HttpCode(HttpStatus.NO_CONTENT)
  remove(@Param('id') id: string) {
    const deleted = this.catsService.remove(+id);
    if (!deleted) {
      throw new NotFoundException(`Cat with ID ${id} not found`);
    }
    return;
  }
}
