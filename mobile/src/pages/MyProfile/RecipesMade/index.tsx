import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const RecipesMade: React.FC<StackScreenProps<
  MyProfileStack,
  'RecipesMade'
>> = ({ navigation }) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> RecipesMade</Text>
      </View>
    </>
  );
};

export default RecipesMade;
