import React from 'react';
import { List, Datagrid, TextField } from 'react-admin';

export default function ColorsList() {
  return (
    <List perPage={50} pagination={false} title="Доступные цвета">
      <Datagrid bulkActionButtons={false} rowClick={false}>
        <TextField source="id" label="ID" />
        <TextField source="name" label="Цвет" />
      </Datagrid>
    </List>
  );
}
