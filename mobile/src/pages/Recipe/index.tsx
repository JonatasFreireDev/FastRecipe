import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { RecipeStack } from '../../interface/IRoutes';

const Recipe: React.FC<StackScreenProps<RecipeStack, 'Recipe'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Recipe</Text>
      </View>
    </>
  );
};

export default Recipe;
