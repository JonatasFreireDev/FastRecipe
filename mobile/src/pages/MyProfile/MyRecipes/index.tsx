import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const MyRecipes: React.FC<StackScreenProps<MyProfileStack, 'MyRecipes'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> MyRecipes</Text>
        <Button
          title="Search"
          onPress={() => navigation.navigate('Favorites')}
        />
      </View>
    </>
  );
};

export default MyRecipes;
