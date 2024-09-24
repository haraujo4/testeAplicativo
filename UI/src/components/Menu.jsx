import React from 'react';
import { Link } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';

const Menu = () => {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Atendimento
        </Typography>
        <Button color="inherit" component={Link} to="/">Home</Button>
        <Button color="inherit" component={Link} to="/pacientes">Cadastro de Pacientes</Button>
        <Button color="inherit" component={Link} to="/painel">Painel de Atendimento</Button>
      </Toolbar>
    </AppBar>
  );
};

export default Menu;
