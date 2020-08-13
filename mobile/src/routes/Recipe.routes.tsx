import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';

import Recipe from '../pages/Recipe';
import YourOpnion from '../pages/Recipe/YourOpnion';
import PersonPerfil from '../pages/Recipe/PersonPerfil';

const RecipeRouter: React.FC = () => {
  const Stack = createStackNavigator();

  return (
    <Stack.Navigator
      screenOptions={{
        headerShown: false,
      }}
    >
      <Stack.Screen name="Recipe" component={Recipe} />
      <Stack.Screen name="YourOpnion" component={YourOpnion} />
      <Stack.Screen name="PersonPerfil" component={PersonPerfil} />
    </Stack.Navigator>
  );
};

export default RecipeRouter;
