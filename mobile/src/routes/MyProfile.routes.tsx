import React from 'react';
import { createStackNavigator } from '@react-navigation/stack';

import MyProfile from '../pages/MyProfile';
import Perfil from '../pages/MyProfile/Perfil';
import MyRecipes from '../pages/MyProfile/MyRecipes';
import RecipesMade from '../pages/MyProfile/RecipesMade';
import CreateRecipe from '../pages/MyProfile/CreateRecipe';
import Favorites from '../pages/MyProfile/Favorites';
import Help from '../pages/MyProfile/Help';
import HelpUs from '../pages/MyProfile/HelpUs';

const MyProfileRouter: React.FC = () => {
  const Stack = createStackNavigator();

  return (
    <Stack.Navigator
      initialRouteName="Home"
      screenOptions={{
        headerShown: false,
      }}
    >
      <Stack.Screen name="Home" component={MyProfile} />
      <Stack.Screen name="Perfil" component={Perfil} />
      <Stack.Screen name="MyRecipes" component={MyRecipes} />
      <Stack.Screen name="RecipesMade" component={RecipesMade} />
      <Stack.Screen name="CreateRecipe" component={CreateRecipe} />
      <Stack.Screen name="Favorites" component={Favorites} />
      <Stack.Screen name="Help" component={Help} />
      <Stack.Screen name="HelpUs" component={HelpUs} />
    </Stack.Navigator>
  );
};

export default MyProfileRouter;
