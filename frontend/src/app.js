import { Navigate, useRoutes } from 'react-router-dom';
import { StyledEngineProvider, ThemeProvider } from '@material-ui/core';

import GlobalStyles from './components/global-styles';
import GlobalTheme from './components/global-theme';
import Layout from './components/layout/layout';
import NotFound from './pages/not-found';
import Players from './pages/players';
import React from 'react';

const routes = [
  {
    path: 'app',
    element: <Layout isLoggedIn={true}/>,
    children: [
      { path: 'players', element: <Players/> },
      { path: '*', element: <Navigate to='/not-found'/> }
    ]
  },
  {
    path: '/',
    element: <Layout isLoggedIn={false}/>,
    children: [
      { path: 'not-found', element: <NotFound/> },
      { path: '/', element: <Navigate to='/app/players'/> },
      { path: '*', element: <Navigate to='/not-found'/> }
    ]
  }
];

const theme = GlobalTheme();

export default function App() {
  const routing = useRoutes(routes);
  
  return (
    <StyledEngineProvider injectFirst>
      <ThemeProvider theme={theme}>
        <GlobalStyles theme={theme}/>
        {routing}
      </ThemeProvider>
    </StyledEngineProvider>
  );
}