import React from 'react';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';

import Home from './Home.routes';
import Storage from '../pages/Storage';
import MyProfile from './MyProfile.routes';

import Login from '../pages/Login';
import Register from '../pages/Register';

const Router: React.FC = () => {
  const isLogin = true;

  const TabNavigation = createBottomTabNavigator();
  const StackNavigation = createStackNavigator();

  return isLogin ? (
    <TabNavigation.Navigator initialRouteName="Home">
      <TabNavigation.Screen name="Storage" component={Storage} />
      <TabNavigation.Screen name="Home" component={Home} />
      <TabNavigation.Screen name="MyProfile" component={MyProfile} />
    </TabNavigation.Navigator>
  ) : (
    <StackNavigation.Navigator
      initialRouteName="Login"
      screenOptions={{
        headerShown: false,
      }}
    >
      <StackNavigation.Screen name="Login" component={Login} />
      <StackNavigation.Screen name="Register" component={Register} />
    </StackNavigation.Navigator>
  );
};

export default Router;
